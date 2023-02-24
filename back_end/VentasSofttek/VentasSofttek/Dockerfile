#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["VentasSofttek/VentasSofttek.csproj", "VentasSofttek/"]
COPY ["VentasSofttek.DTO/VentasSofttek.DTO.csproj", "VentasSofttek.DTO/"]
COPY ["VentasSofttek.Models/VentasSofttek.Models.csproj", "VentasSofttek.Models/"]
COPY ["VentasSofttek.DAL/VentasSofttek.DAL.csproj", "VentasSofttek.DAL/"]
RUN dotnet restore "VentasSofttek/VentasSofttek.csproj"
COPY . .
WORKDIR "/src/VentasSofttek"
RUN dotnet build "VentasSofttek.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VentasSofttek.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ln -fs /usr/share/zoneinfo/America/Lima /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata
ENTRYPOINT ["dotnet", "VentasSofttek.dll"]