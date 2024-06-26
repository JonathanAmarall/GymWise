FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/building blocks/GymWise.Core/GymWise.Core.csproj", "src/building blocks/GymWise.Core/"]
COPY ["src/services/GymWise.Api/GymWise.Api.csproj", "src/services/GymWise.Api/"]
COPY ["src/services/GymWise.Workout.Application/GymWise.Workout.Application.csproj", "src/services/GymWise.Workout.Application/"]
COPY ["src/services/GymWise.Workout.Domain/GymWise.Workout.Domain.csproj", "src/services/GymWise.Workout.Domain/"]
COPY ["src/services/GymWise.Workout.Infra/GymWise.Workout.Infra.csproj", "src/services/GymWise.Workout.Infra/"]
COPY ["src/services/GymWise.Student.Application/GymWise.Student.Application.csproj", "src/services/GymWise.Student.Application/"]
COPY ["src/services/GymWise.Student.Domain/GymWise.Student.Domain.csproj", "src/services/GymWise.Student.Domain/"]
COPY ["src/services/GymWise.Student.Infra/GymWise.Student.Infra.csproj", "src/services/GymWise.Student.Infra/"]
RUN dotnet restore "src/services/GymWise.Api/GymWise.Api.csproj"
COPY . .
WORKDIR "/src/src/services/GymWise.Api"
RUN dotnet build "GymWise.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GymWise.Api.csproj" -c Release -p:Environment=Staging -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymWise.Api.dll"]