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
The web server will be available at `http://localhost:4000/` and api at `http://localhost:4001/`

## Run project without docker (development mode)
This requires dotnet 5.0 SDK and Angular CLI 11.2.2

### Install packages
```
cd banqsoft-web
npm install
```
```
dotnet restore banqsoft-api
```

### Start projects
```
dotnet run --project banqsoft-api
```
Api will start by default on port 5001
```
cd banqsoft-web
npm run start
```
Web will start by default on port 4200

## Running tests
```
npm run test --prefix banqsoft-web
```
```
dotnet test banqsoft-api-test
```
