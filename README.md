# Capital Gain CLI

## Context
Capital Gain CLI is a simple program that calculates how much tax should be paid over profits and losses on stock operations.

## Architecture
Its architecture is divided in two main libraries: CLI and Domain. Although is a simple calculation, it would be way more easy to implement some other interfaces or features if user interface and domain rules were segregated. This way, for example, this system could have a REST API so other systems could integrate on it and so on. Also, if the user interface had to be modified, the main business rules would be safe.

![Sequence diagram](https://mermaid.ink/img/pako:eNqdksFOwzAMhl8lynl7gRx2GUgMIZjouPViJV6JlCbDSbqhae-OS1qo0LoDOViV8_ur89tnqYNBqWTEj4xe452FhqCtveCzftosVyuOSryiRtthFDkiCesPOU01b5zd9MkH8MYhKbGl0FnDBQTHqf6v8mrxjsBHB2kof6xenguDYwrChBasFw58k6HBWfAOTmtwOjPJBl8hdVZj_xZ-a0xC_94VxFX9PGfMcZeswHgbcsOiBKdpM4IwZvdfv75ri0-jd7OkYbQpk4_F5emvJ-PfEgN_4Izu16CoShyPXMgWicdjeKnO_V0t0zu2WEvFnwb30PNl7S8szQfDTd8bmwJJtQcXcSEhp1B9ei1VooyjaFjMQXX5AkbP8w4)

## Frameworks and Libraries

This project uses two extra frameworks besides standard .NET applications. Newtonsoft and Autofixture.

Newtonsoft - A powerful JSON serialization framework that enables to serialize and deserialize any .NET object.
Autofixture - An opensource library that minimize unit tests setups. It helps to create test mass faster and more easily.

## How to run the project

To run Capital Gain CLI you can run using **pure dotnet core**, which works in Windows, Linux and Mac OS or using **Docker**.

### Using Docker
- Download Docker
- In root folder, the one with the Dockerfile, run `docker build -t capital_gain .` in terminal.
- After building image, execute `docker run -i capital_gain`.
- There you go, now you can test it out!

### Using dotnet
- In root folder, run in terminal `dotnet run .\CapitalGainCli.csproj`.

### Making changes and testing it
If you want to change something in the code and test it, you should republish the project executable before using Docker. Using dotnet you have no worries, just save your changes and go for your dotnet run.

Before using docker again, you should publish a new version of the app. To do that, you must run `dotnet publish -c Release`. Notes that you have to have .NET Core SDK installed. After publishing, you can run your container again.

### Running project tests
To run its tests, all you have to do is execute `dotnet test` on root folder.

### General observations
- The most important test cases were written in TaxCalculationService, which holds core business rules.
- The UserInputHandler tests only focus on handler major responsibilities, which are serializing data and handling inputs independently and error safe.
