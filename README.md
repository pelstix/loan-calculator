[![Build Status](https://dev.azure.com/trutkowski0349/loan-calculator/_apis/build/status/rutkowski-tomasz.loan-calculator?branchName=master)](https://dev.azure.com/trutkowski0349/loan-calculator/_build/latest?definitionId=2&branchName=master)

# LoanCalculator app
Web application which can be used for calculation the cost of a housing loan
(In progress) Azure CI/CD integration

## Application preview
![image](https://user-images.githubusercontent.com/11985426/109799518-6d52bf00-7c1c-11eb-99c5-205ddae29ac2.png)


## Prerequiremts:
- Installed docker (tested on Docker v20.10.2, docker-compose v1.27.4)

## Start project (production mode)
```
docker-compose up
```
The web server will be available at `http://localhost:4000/` and api at `http://localhost:4001/`

## Run project without docker (development mode)
Development prerquirements:
- Dotnet 5.0 SDK
- Angular CLI 11.2.2
- Node v14.16.0

### Installing packages
```
cd banqsoft-web
npm install
```
```
dotnet restore banqsoft-api
```

### Starting projects
Before starting projects make sure you have installed the packages.
```
dotnet run --project banqsoft-api
```
```
cd banqsoft-web
npm run start
```
The web server will be available at `http://localhost:4200/` and api at `http://localhost:5001/`

### Running tests
Before running tests make sure you have installed the packages.
```
cd banqsoft-web
npm run test
npm run lint
```
```
dotnet test banqsoft-api-test
```
