FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install -y nodejs

COPY . .

ARG ASSEMBLY_COMPANY="ResDiary Ltd"
ARG ASSEMBLY_COPYRIGHT="Copyright (c) 2011-2020 ResDiary Ltd"
ARG ASSEMBLY_VERSION="1.0.0"
ARG ASSEMBLY_INFORMATIONAL_VERSION="1.0.0-local"
ARG TEAMCITY_VERSION=""

RUN dotnet test /p:"TEAMCITY_VERSION=${TEAMCITY_VERSION}" ./RD.Webapp.Template/src/RD.Webapp.Template.Tests --verbosity=normal
RUN dotnet publish ./RD.Webapp.Template/src/RD.Webapp.Template/RD.Webapp.Template.csproj -c Release -o /app /p:"Company=${ASSEMBLY_COMPANY};Copyright=${ASSEMBLY_COPYRIGHT};AssemblyVersion=${ASSEMBLY_VERSION};FileVersion=${ASSEMBLY_VERSION};InformationalVersion=${ASSEMBLY_INFORMATIONAL_VERSION}"

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "RD.Webapp.Template.dll"]
