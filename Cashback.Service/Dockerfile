FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Cashback.Service/Cashback.Service.csproj", "Cashback.Service/"]
COPY ["Cashback.Infrascructure.Database/Cashback.Database.csproj", "Cashback.Infrascructure.Database/"]
COPY ["Cashback.Model/Cashback.Domain.csproj", "Cashback.Model/"]
COPY ["Cashback.Commom/Cashback.Commom.csproj", "Cashback.Commom/"]
COPY ["Cashback.Cross.IoC/Cashback.Cross.IoC.csproj", "Cashback.Cross.IoC/"]
COPY ["Cashback.Infrastructure.ExternalServices.Spotify/Cashback.ExternalServices.Spotify.csproj", "Cashback.Infrastructure.ExternalServices.Spotify/"]
RUN dotnet restore "Cashback.Service/Cashback.Service.csproj"
COPY . .
WORKDIR "/src/Cashback.Service"
RUN dotnet build "Cashback.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Cashback.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cashback.Service.dll"]