FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/MyTeamsCalender.Web.Host/MyTeamsCalender.Web.Host.csproj", "src/MyTeamsCalender.Web.Host/"]
COPY ["src/MyTeamsCalender.Web.Core/MyTeamsCalender.Web.Core.csproj", "src/MyTeamsCalender.Web.Core/"]
COPY ["src/MyTeamsCalender.Application/MyTeamsCalender.Application.csproj", "src/MyTeamsCalender.Application/"]
COPY ["src/MyTeamsCalender.Core/MyTeamsCalender.Core.csproj", "src/MyTeamsCalender.Core/"]
COPY ["src/MyTeamsCalender.EntityFrameworkCore/MyTeamsCalender.EntityFrameworkCore.csproj", "src/MyTeamsCalender.EntityFrameworkCore/"]
WORKDIR "/src/src/MyTeamsCalender.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MyTeamsCalender.Web.Host", "src/MyTeamsCalender.Web.Host"]
COPY ["src/MyTeamsCalender.Web.Core", "src/MyTeamsCalender.Web.Core"]
COPY ["src/MyTeamsCalender.Application", "src/MyTeamsCalender.Application"]
COPY ["src/MyTeamsCalender.Core", "src/MyTeamsCalender.Core"]
COPY ["src/MyTeamsCalender.EntityFrameworkCore", "src/MyTeamsCalender.EntityFrameworkCore"]
WORKDIR "/src/src/MyTeamsCalender.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyTeamsCalender.Web.Host.dll"]
