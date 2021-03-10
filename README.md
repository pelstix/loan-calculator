[![Build Status](https://loan-calculator-organization.visualstudio.com/loan-calculator-project/_apis/build/status/rutkowski-tomasz.loan-calculator?branchName=master)](https://loan-calculator-organization.visualstudio.com/loan-calculator-project/_build/latest?definitionId=1&branchName=master)

# LoanCalculator app
Web application which can be used for calculation the cost of a housing loan

(In progress) Azure CI integration
(In progress) Azure CD integration

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

## Azure CI integration
Integrated with azure pipelines - see azure-pipelines.yml file.

Separate jobs were created to handle integration of both Web and Api project.
| Web CI        | Api CI  |
| ------------- |-------------|
| ![image](https://user-images.githubusercontent.com/11985426/110608580-ac3cc380-818c-11eb-9475-c9c20288616c.png) | ![image](https://user-images.githubusercontent.com/11985426/110608734-caa2bf00-818c-11eb-90f5-8991e6e0a6a9.png) |
| Duration: ~3m | Duration: ~1m |

Both jobs perform unit tests and collect code coverage reports. Testing results are integrated with pipeline and displayed as data of each pipeline run.
![image](https://user-images.githubusercontent.com/11985426/110609398-764c0f00-818d-11eb-97aa-4a7aa6964383.png)

Unit tests results:
![image](https://user-images.githubusercontent.com/11985426/110609523-95e33780-818d-11eb-94fc-b3a3278cd79b.png)

Code coverage results:
![image](https://user-images.githubusercontent.com/11985426/110609622-b14e4280-818d-11eb-8626-19f11b39a67e.png)



