#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Clean_Architecture/Clean_Architecture.csproj", "Clean_Architecture/"]
RUN dotnet restore "Clean_Architecture/Clean_Architecture.csproj"
COPY . .
WORKDIR "/src/Clean_Architecture"
RUN dotnet build "Clean_Architecture.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clean_Architecture.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clean_Architecture.dll"]