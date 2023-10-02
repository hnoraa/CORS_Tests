# CORS_Tests
Testing CORS functionality. This is mainly for reference because it's one of those things I run into every so often.

## Projects
|Name|Description|
|----|-----------|
|CORSTests|A Visual Studio project with a React frontend and Asp .net core backend|

## CORSTests (Visual Studio solution)
### Requirements
- IIS (>= 10.0.22621.1)
- IIS CORS Module
- .Net 7 Hosting Bundle
- Visual Studio 2022 (>= 17.7.4)
- Node.js (>= 20.3.1)
- npx (>= 9.6.7)

### Reproducing
#### IIS
 - Set up a new website for the API. I created the folder within inetpub\www
 - Set up a new website for the UI. Did the same thing with the folder here

#### Visual Studio
 - Set up a publish to the API folder in IIS (from the api project)
 - Set up a publish to the UI folder in IIS (from the ui project)

#### Misc
 - npm install on the ui

#### Running
I just ran the backend from IIS and the frontend within the cli (`npm start`). 
To see the full effect, you can comment out line: 35 in Program.cs in the API project. 
When you comment that out, the UI wont load the data correctly giving you CORS errors in the browsers Dev Tools.