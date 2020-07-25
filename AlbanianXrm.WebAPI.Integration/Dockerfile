#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AlbanianXrm.WebAPI.Integration/AlbanianXrm.WebAPI.Integration.csproj", "AlbanianXrm.WebAPI.Integration/"]
RUN dotnet restore "AlbanianXrm.WebAPI.Integration/AlbanianXrm.WebAPI.Integration.csproj"
COPY . .
WORKDIR "/src/AlbanianXrm.WebAPI.Integration"
RUN dotnet build "AlbanianXrm.WebAPI.Integration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlbanianXrm.WebAPI.Integration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlbanianXrm.WebAPI.Integration.dll"]