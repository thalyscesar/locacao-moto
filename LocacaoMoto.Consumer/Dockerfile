#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LocacaoMoto.Consumer/LocacaoMoto.Consumer.csproj", "LocacaoMoto.Consumer/"]
RUN dotnet restore "LocacaoMoto.Consumer/LocacaoMoto.Consumer.csproj"
COPY . .
WORKDIR "/src/LocacaoMoto.Consumer"
RUN dotnet build "LocacaoMoto.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocacaoMoto.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocacaoMoto.Consumer.dll"]