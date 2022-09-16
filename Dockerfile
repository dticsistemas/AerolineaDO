FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-end
WORKDIR /app
COPY . .
RUN dotnet restore "./ControlDocumentoFactura.WebApi/ControlDocumentoFactura.WebApi.csproj" 
RUN dotnet publish "./ControlDocumentoFactura.WebApi/ControlDocumentoFactura.WebApi.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:5.0 

EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

COPY --from=build-end /app/publish .
ENTRYPOINT ["dotnet", "ControlDocumentoFactura.WebApi.dll"]