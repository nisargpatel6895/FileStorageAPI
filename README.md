# FileStorageAPI

**Problem Statement** 

Design and implement a simple file storage API service. This storage has to accept any type of binary files and support versioning. and saved to the database. A user of this API should be able to create/update/delete/list file(s). 
It should have at least 1 unit test integration.
Tech Stack used - .Net Core 7, Sqlite and Entity Framework
 

### Usage

1. Clone the repo
   ```sh
   git clone https://github.com/nisargpatel6895/FileStorageAPI.git
   ```

2. The repository contains
    <li> FileStorageAPI : It contains solution files pertaining create,read, update and delete apis for storing a file </li>
    <li> FileStorageAPI-test : It contains a sample unit test which asserts file upload functionality </li>
    
3. Setting up the database
   The solution has been created using CodeFirst approach in Entity Framework. This helps in creating the database and tables based on entity       classes(FileData) and configurations given on DbContext. Below are the commands that are run in package manager console
   ```sh
   dotnet ef migration add {migration_name}
   dotnet ef database update
   ```
4. Once the database has been setup build and run the solution to see the swagger ui in the browser as shown below. 
<img width="1433" alt="Screen Shot 2022-12-13 at 10 04 48 AM" src="https://user-images.githubusercontent.com/11133420/207410747-847bb8a6-410c-4540-ae0d-4b957a4a39ec.png">

The Endpoints of the APIs are: 
 <li>POST : /FileData/UploadFile
  To test this endpoint using swagger ui - Enter **UserId** as any integer value greater than 0 and upload a single file under **File** in request body.
  </li>
 <li>GET : /FileData/DownloadFile
  To test this endpoint using swagger ui - This endpoint takes FileId as a parameter. Enter **Id** as any integer value greater than 0.
 </li>
 <li>PUT : /FileData/UpdateFile
  To test this endpoint using swagger ui - This endpoint takes FileId as a parameter. Enter **UserId** as any integer value greater than 0 and upload a single file under **File** in request body.
 </li>
 <li>DELETE : /FileData/DeleteFile
  To test this endpoint using swagger ui - This endpoint takes FileId as a parameter. Enter **Id** as any integer value greater than 0.
 </li>
 
 
### Test
To test this api a sample unit test has been implemented which asserts the upload file endpoint as shown below
 <img width="1434" alt="Screen Shot 2022-12-13 at 11 29 13 AM" src="https://user-images.githubusercontent.com/11133420/207427042-1e2dd5c1-7b41-4639-803f-596429b51851.png">
