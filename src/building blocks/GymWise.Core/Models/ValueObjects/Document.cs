using GymWise.Core.Errors;
using GymWise.Core.Models.Result;
using GymWise.Core.Primitives;
using System.Text.RegularExpressions;

namespace GymWise.Core.Models.ValueObjects
{
    public class Document : ValueObject
    {
        public const short CpfLength = 11;
        public const short CnpjLength = 14;
        public static short MaxLength => CnpjLength;

        protected Document(string value) => Value = value;

        public string Value { get; private set; }

        public bool IsCpf => Value.Length == CpfLength;
        public bool IsCnpj => !IsCpf;


        public static Result<Document> Create(string document)
        {
            if (string.IsNullOrWhiteSpace(document))
            {

                return Result.Result.Failure<Document>(DomainErrors.Document.InvalidDocumentLength);
            }

            var documentWithoutSpecialCaracters = RemoveSpecialCaracters(document);

            if (documentWithoutSpecialCaracters.Length == CpfLength)
            {
                return Result.Result
                    .Create(documentWithoutSpecialCaracters, DomainErrors.Document.InvalidDocument)
                    .Ensure(doc => IsValidCPF(doc), DomainErrors.Document.InvalidDocument)
                    .Map(doc => new Document(doc));
            }

            if (documentWithoutSpecialCaracters.Length == CnpjLength)
            {
                return Result.Result
                   .Create(documentWithoutSpecialCaracters, DomainErrors.Document.InvalidDocument)
                   .Ensure(doc => IsValidCNPJ(doc), DomainErrors.Document.InvalidDocument)
                   .Map(doc => new Document(doc));
            }

            return Result.Result.Failure<Document>(DomainErrors.Document.InvalidDocumentLength);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        static bool IsValidCPF(string cpf)
        {
            if (new string(cpf[0], 11) == cpf)
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            int rest = sum % 11;
            int firstDigitVerifier = rest < 2 ? 0 : 11 - rest;

            if (int.Parse(cpf[9].ToString()) != firstDigitVerifier)
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            rest = sum % 11;
            int secondDigitVerifier = rest < 2 ? 0 : 11 - rest;

            if (int.Parse(cpf[10].ToString()) != secondDigitVerifier)
                return false;

            return true;
        }

        static bool IsValidCNPJ(string cnpj)
        {
            int[] firstMultipliers = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            for (int i = 0; i < 12; i++)
                sum += int.Parse(cnpj[i].ToString()) * firstMultipliers[i];
            int resto = sum % 11;
            int firstDigitVerifier = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cnpj[12].ToString()) != firstDigitVerifier)
                return false;

            int[] secondMultipliers = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(cnpj[i].ToString()) * secondMultipliers[i];
            resto = sum % 11;
            int secondDigitVerifier = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cnpj[13].ToString()) != secondDigitVerifier)
                return false;

            return true;
        }

        private static string RemoveSpecialCaracters(string value)
            => Regex.Replace(value, @"[^\d]", "");
    }
}
