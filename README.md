# LoanCalculator app
Web application 

## Application preview
![image](https://user-images.githubusercontent.com/11985426/109799518-6d52bf00-7c1c-11eb-99c5-205ddae29ac2.png)


## Prerequiremts:
- Installed docker (tested on Docker v20.10.2, docker-compose v1.27.4)

## Start project (production mode)
```
docker-compose up
```

## Run project without docker (development mode)
This requires dotnet 5.0 SDK and Angular CLI 11.2.2

### Install packages
```
npm --prefix ./banqsoft-web install ./banqsoft-web
```
```
dotnet restore banqsoft-api
```

### Start projects
```
dotnet run --project banqsoft-api
```
```
npm run start --prefix banqsoft-web
```

## Running tests
```
npm run test --prefix banqsoft-web
```
```
dotnet test banqsoft-api-test
```
