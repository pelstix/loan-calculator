# Prerequiremts:
- installed docker

# Start project (production mode)
`docker-compose up`

# Run project without docker (development mode)
This requires dotnet 5.0 SDK and Angular CLI 11.2.2

## Install packages
`npm --prefix ./banqsoft-web install ./banqsoft-web`
`dotnet restore banqsoft-api`

## Start projects
`dotnet run --project banqsoft-api`
`npm run start --prefix banqsoft-web`

# Running tests
`npm run test --prefix banqsoft-web`
`dotnet test banqsoft-api-test`