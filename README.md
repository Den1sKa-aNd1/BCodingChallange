# Bunnings Coding Challenge API
This is a solution to the coding challenge exercise.
The format of the solution was selected as `.Net Core API Application` due to nature of the data processing.
## Assumptions
- Due to `Input` and `output` `CSV` formats/headers had to create multiple models to receive a requested result.
- Didn't implement data clean up for Suppliers and Barcodes as it is not a part of output.

## How to run the project
1. Pull the project from the repo.
2. Open `Terminal` in the `root folder` of the project.
3. run `dotnet restore` command.
4. run `cd BunningsCodingChallengeAPI` command.
5. run `dotnet run` command. This will launch the API and it is ready to go.
6. Open browser and navigate to [Swagger Page](https://localhost:5001/swagger/index.html)
7. Select `Post` request from `Catalog` controller and press `Try it out` button.
8. In the request body set the company names (`A` and `B`). Your request body should looks like this: 
```json
{
  "companyNameA": "A",
  "companyNameB": "B"
}
```
9. Press `Execute` button.
10. You should get the output in the `Responses` section of the form and also a new `csv` file will be created in the `./OutputFiles` folder with the name `result_output_{DateTime.Now.Ticks}`.

## How to run the tests
1. Pull the project from the repo (unless you already downloaded it).
2. Open `Terminal` in the `root folder` of the project.
3. run `dotnet restore` command.
4. run `dotnet test` command.
5. Make sure you get `success` result by having similar to below output:
```
Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 196 ms
```