using GymWise.Workout.Domain.Entities;
using GymWise.Workout.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymWise.Workout.Infra.Seeder
{
    public static class DataSeeder
    {
        public static async Task ApplySeeders(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<WorkoutDbContext>();
                if (context.Database.IsRelational())
                {
                    var connections = context.Database.GetDbConnection();
                    Console.WriteLine("======= CRIANDO BANCO DE DADOS: {0} =======\n", connections.ConnectionString);
                }

                Console.WriteLine("======= APLICANDO MIGRATIONS =======\n");
                context.Database.Migrate();

                var exercises = new List<Exercise>()
                {
                    // Peitoral
                    new Exercise("Supino Reto Barra" ,"https://youtu.be/sqOw2Y6uDWQ"),
                    new Exercise("Supino Reto Halteres" ,"https://youtu.be/Spbmm66NsuY"),
                    new Exercise("Supino Reto Smith" ,"https://youtu.be/b-THwNtIYxY"),
                    new Exercise("Supino Inclinado Barra" ,"https://youtu.be/lBCjPgnIzKk"),
                    new Exercise("Supino Inclinado Halteres" ,"https://youtu.be/Z1rCZ0YHrP0"),
                    new Exercise("Supino Inclinado Smith" ,"https://youtu.be/L4kIk2gMeBw"),
                    new Exercise("Supino Declinado Barra" ,"https://youtu.be/hZ9woVlzGdA"),
                    new Exercise("Supino Declinado Halteres" ,"https://youtu.be/0SFB2chQTPY"),
                    new Exercise("Supino Declinado Smith" ,"https://youtu.be/xLQ9ZbH9ljc"),
                    new Exercise("Crucifixo Reto Halteres" ,"https://youtu.be/dQi36EfA88c"),
                    new Exercise("Crucifixo Inclinado Halteres" ,"https://youtu.be/4JvT5Ys1Bog"),
                    new Exercise("Crucifixo Declinado Halteres" ,"https://youtu.be/QsZ8VYaRh34"),
                    new Exercise("Over Polia Alta" ,"https://youtu.be/HNUji0rHFCs"),
                    new Exercise("Over Polia Média" ,"https://youtu.be/iLRFLm82dbg"),
                    new Exercise("Over Polia Baixa" ,"https://youtu.be/Jy_hZnK"),
                    new Exercise("Flexão De Braço" ,"https://youtu.be/F9FC_KBsLpY"),
                    new Exercise("Crucifixo Na Máquina" ,"https://youtu.be/Ru9OVOUlp0U"),
                    // Dorsal
                    new Exercise("Barra Fixa PegPronada" ,"https://youtu.be/JX_YM7Bp26U"),
                    new Exercise("Barra Fixa PegSupinada" ,"https://youtu.be/WJOu_aru3XM"),
                    new Exercise("Barra Fixa Com Triângulo" ,"https://youtu.be/uCnm"),
                    new Exercise("Levantamento Terra" ,"https://youtu.be/T3x53s0jEns"),
                    new Exercise("Puxada Vertical PegPronada" ,"https://youtu.be/H09EvebBsB4"),
                    new Exercise("Puxada Vertical PegSupinada" ,"https://youtu.be/v1rPzvJvwIE"),
                    new Exercise("Puxada Vertical Com Triângulo" ,"https://youtu.be/ej9Z_jMQpLY"),
                    new Exercise("Remada Curvada PegPronada" ,"https://youtu.be/XruycmUNi1Y"),
                    new Exercise("Remada Curvada PegSupinada" ,"https://youtu.be/y-XZnuKx3Q0"),
                    new Exercise("Remada Curvada Cavalinho" ,"https://youtu.be/Hdqf7mlEHrA"),
                    new Exercise("Remada Curvada Halteres PegPronada" ,"https://youtu.be/AT8pPML17VU"),
                    new Exercise("Remada Curvada Halteres PegSupinada" ,"https://youtu.be/g0VduhIsJIE"),
                    new Exercise("Remada Curvada Halteres Peg Neutra" ,"https://youtu.be/CyCkDYs49hM"),
                    new Exercise("Remada Máquina PegPronada" ,"https://youtu.be/_g6GeyWVivI"),
                    new Exercise("Remada Máquina Peg Neutra" ,"https://youtu.be/C0-C0X7G8eQ"),
                    new Exercise("Remada Cross PegPronada" ,"https://youtu.be/IA0SRm2mY9M"),
                    new Exercise("Remada Cross PegSupinada" ,"https://youtu.be/Q5Rl_fnOCBs"),
                    new Exercise("Remada Cross Peg Neutra" ,"https://youtu.be/wC1EsDy_esM"),
                    new Exercise("Remada Unilateral PegPronada" ,"https://youtu.be/VlCc"),
                    new Exercise("Remada Unilateral PegSupinada" ,"https://youtu.be/MAHNlcA4oXc"),
                    new Exercise("Remada Unilateral Peg Neutra" ,"https://youtu.be/C-tlPEhjwTk"),
                    new Exercise("Pull-Down Barra" ,"https://youtu.be/qw37xEEcoig"),
                    new Exercise("Pull-Down Cross Peg Pronada" ,"https://youtu.be/EG1ua8lDQJA"),
                    new Exercise("Pull-Down Cross Peg Supinada" ,"https://youtu.be/U80znmkD2z0"),
                    new Exercise("Pull-Down Cross Corda" ,"https://youtu.be/zdLHXB9Sn88"),
                    //Deltoides
                    new Exercise("Elevação Lateral Sentado Halteres" ,"https://youtu.be/esWhjFJMNtU"),
                    new Exercise("Elevação Lateral Cross Posterior" ,"https://youtu.be/I-ywK8Q"),
                    new Exercise("Elevação Lateral Cross Anterior" ,"https://youtu.be/8KOat8ZsidI"),
                    new Exercise("Elevação Lateral Unilateral Banco Inclinado" ,"https://youtu.be/8s9JRhE95mU"),
                    new Exercise("Elevação Frontal Barra PegPronada" ,"https://youtu.be/jXUIrrvlR_0"),
                    new Exercise("ão Frontal Barra PegSupinada" ,"https://youtu.be/Ea_8qpcysYI"),
                    new Exercise("Elevação Frontal Halteres PegPronada" ,"https://youtu.be/0K9NJHXYSm4"),
                    new Exercise("Elevação Frontal Halteres PegSupinada" ,"https://youtu.be/DuUh84gcaso"),
                    new Exercise("Elevação Frontal Halteres Peg Neutra" ,"https://youtu.be/kQTNDsaEIKc"),
                    new Exercise("Elevação Frontal Cross PegPronada" ,"https://youtu.be/mOTjgenwgUc"),
                    new Exercise("Elevação Frontal Cross PegSupinada" ,"https://youtu.be/lL8hIRuFcnU"),
                    new Exercise("Elevação Frontal Cross Corda" ,"https://youtu.be/xCQLo6LcudM"),
                    new Exercise("Frontal Anilha" ,"https://youtu.be/5bdlcZZvpzE"),
                    new Exercise("Elevação Frontal Cruzada" ,"https://youtu.be/btAEYSe5kp0"),
                    new Exercise("Crucifixo Inverso Halteres" ,"https://youtu.be/SLQZOByDo04"),
                    new Exercise("Crucifixo Inverso Cross" ,"https://youtu.be/gWa5abtK4G4"),
                    new Exercise("Desenvolvimento Halteres" ,"https://youtu.be/4pU"),
                    new Exercise("Desenvolvimento Anterior" ,"https://youtu.be/V_15VvJ3mr4"),
                    new Exercise("Desenvolvimento Posterior" ,"https://youtu.be/WIlm9oHEEq8"),
                    new Exercise("Desenvolvimento Militar" ,"https://youtu.be/urj7vgvfojk"),
                    new Exercise("Desenvolvimento Smith" ,"https://youtu.be/oi18jaIbFRM"),
                    new Exercise("Desenvolvimento Máquina" ,"https://youtu.be/oBF4YIwh_w8"),
                    new Exercise("Manguito Rotador Externo Barra" ,"https://youtu.be/QdUn8TBdjvU"),
                    new Exercise("Manguito Rotador Externo Halteres" ,"https://youtu.be/2ecstA3a5f4"),
                    // Trapezio
                    new Exercise("Encolhimento Barra Posterior" ,"https://youtu.be/Y4w7ZZW84eM"),
                    new Exercise("Encolhimento Halteres" ,"https://youtu.be/ZzJ3zelC0qI"),
                    new Exercise("Encolhimento Smith Anterior" ,"https://youtu.be/5DQl_71T8iI"),
                    new Exercise("Encolhimento Smith Posterior" ,"https://youtu.be/7Ui8zi1w5A4"),
                    new Exercise("Remada Alta Halteres" ,"https://youtu.be/hFMCum41W9c"),
                    new Exercise("Remada Alta Barra" ,"https://youtu.be/Z6jSLKXZ0Ag"),
                    new Exercise("Remada Alta Cross" ,"https://youtu.be/dHjEyNaCmn0"),
                    new Exercise("Remada Alta Smith" ,"https://youtu.be/lD_zvmzP1K0"),
                    // Triceps
                    new Exercise("Supino Fechado" ,"https://youtu.be/qJGw6CnVh2Q"),
                    new Exercise("Rosca Testa Barra PegPronada" ,"https://youtu.be/orMEOzQjiAs"),
                    new Exercise("Rosca Testa Barra PegSupinada" ,"https://youtu.be/D_wnqWbIrYs"),
                    new Exercise("Rosca Testa Halteres PegSupinada" ,"https://youtu.be/OS8sz24YV1g"),
                    new Exercise("res Peg Neutra" ,"https://youtu.be/KzKdkwIjZg8"),
                    new Exercise("Rosca Testa Halteres PegPronada" ,"https://youtu.be/esAavWMIRZ8"),
                    new Exercise("Tríceps Pulley Corda" ,"https://youtu.be/_KrR8248eLo"),
                    new Exercise("Tríceps PulleyPegPronada" ,"https://youtu.be/QDt8P44ORa4"),
                    new Exercise("Tríceps PulleyPegSupinada" ,"https://youtu.be/2W09NaNpiOA"),
                    new Exercise("Tríceps Pulley Unilateral PegPronada" ,"https://youtu.be/TmO_85EK09I"),
                    new Exercise("Tríceps Pulley Unilateral PegSupinada" ,"https://youtu.be/iO5EOd9Xe4c"),
                    new Exercise("Rosca Francesa Anilha" ,"https://youtu.be/D2oQJTz"),
                    new Exercise("Rosca Francesa Barra PegPronada" ,"https://youtu.be/fcIzvqXOJzs"),
                    new Exercise("Rosca Francesa Barra PegSupinada" ,"https://youtu.be/xnP"),
                    new Exercise("Rosca Francesa Halteres Peg Neutra" ,"https://youtu.be/aI8x4pHiByU"),
                    new Exercise("Rosca Francesa Halteres PegSupinada" ,"https://youtu.be/KoLqZRyZuuU"),
                    new Exercise("Rosca Francesa Halteres PegPronada" ,"https://youtu.be/DCbDClEDQvQ"),
                    new Exercise("Rosca Francesa Cross Corda" ,"https://youtu.be/QhJ67UyNdsc"),
                    new Exercise("TrícepsCoice Bilateral Halteres" ,"https://youtu.be/lbYQgZvJApA"),
                    new Exercise("TrícepsCoice Unilateral Halteres" ,"https://youtu.be/I4hzS9nYlgs"),
                    new Exercise("Tríceps Coice Unilateral Cross" ,"https://youtu.be/MGlqvfSCWLQ"),
                    new Exercise("Flexão De Braço Fechada" ,"https://youtu.be/9qT4QxmIuuU")
                };

                if (!await context.Set<Exercise>().AsNoTracking().AnyAsync())
                {
                    await context.Set<Exercise>().AddRangeAsync(exercises);

                    DateTime utcNow = DateTime.UtcNow;
                    context.UpdateAuditableEntities(utcNow);

                    await context.SaveChangesAsync();

                    Console.WriteLine("=======SEEDERS FINALIZADOS=======");
                }
            }
        }
    }
}
