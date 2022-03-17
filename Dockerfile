FROM mcr.microsoft.com/dotnet/sdk:5.0
COPY bin/Release/net5.0/publish .
ENTRYPOINT ["dotnet", "CapitalGainCli.dll"]