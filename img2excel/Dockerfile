#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["img2excel/img2excel.csproj", "img2excel/"]
RUN dotnet restore "img2excel/img2excel.csproj"
COPY . .
WORKDIR "/src/img2excel"
RUN dotnet build "img2excel.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "img2excel.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "img2excel.dll"]