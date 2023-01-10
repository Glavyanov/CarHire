# CarHire

***The application provides an opportunity to rent a vehicle from an office after registration and filling out the rental form.
The selection is made through a panel with vehicle categories, which is also the home page***

![Screenshot 2023-01-09 115729](https://user-images.githubusercontent.com/89041019/211303761-b88c6629-2e97-48f3-ae40-8ce9e3b1875b.png)
---
***or through the all vehicles section.***

![Screenshot 2023-01-09 150710](https://user-images.githubusercontent.com/89041019/211315281-bf8adb00-7971-4b66-8ee2-98f6800190d9.png)
---

<br>
<br>
<br>

***It is possible to view the details of the car and comments left by previous renters.<br>
Each user has a section (My Rent) with their current rent through which the vehicle is returned after the end of the rent.***

![Screenshot 2023-01-09 132534](https://user-images.githubusercontent.com/89041019/211317922-b31b1c68-3902-4b6c-b885-85561e26f92a.png)
---

<br>
<br>
<br>

***After granted an access level by the administration, an employee with the rank of manager can edit the data and add new ones
such as: comments, vehicle details, trade discounts, categories.***<br>
***Manager area:***

![Screenshot 2023-01-09 153439](https://user-images.githubusercontent.com/89041019/211320222-d1c9b190-f411-41ad-960d-8f45e5999d4e.png)
---

<br>
<br>
<br>

***An employee with the rank of administrator (which is added automatically with database seeding) can add/remove roles to a given user that give the level of access to the data.***

![Screenshot 2023-01-09 154523](https://user-images.githubusercontent.com/89041019/211322356-740abb55-df19-47fa-a15a-b6db0d7e75ee.png)
---

<br>
<br>
<br>


## :books: Tech Stack

### 1. Back-End

> - ![](https://img.shields.io/badge/Visual%20Studio%202022-v17.4.2-%233b2e58)
> - ![](https://img.shields.io/badge/ASP.NET%20Core-v6.0.8-%23512bd4)
> - ![](https://img.shields.io/badge/ASP.NET%20Core%20Identity-v6.0.8-%23512bd4)
> - ![](https://img.shields.io/badge/EntityFrameworkCore-v6.0.8-blue)
> - ![](https://img.shields.io/badge/MSSQLServer-2019--latest-%23eb0c0c)

### 2. Front-End

> - ![](https://img.shields.io/badge/jQuery-v3.5.1-%230769AD)
> - ![](https://img.shields.io/badge/Bootstrap-v5.1.0-%236610f2)
> - ![](https://img.shields.io/badge/sweetalert2-v11.6.10-%237066e0)

### 3. Tests

> - ![](https://img.shields.io/badge/SQLite-v7.0.0-%230088e9f2)
> - ![](https://img.shields.io/badge/MOQ-v4.8.13-%23ebba06f2)
> - ![](https://img.shields.io/badge/NUnit-v3.13.3-%230e8300)

<br>
<br>
<br>

## 🗺️ Database Diagram

![Screenshot 2023-01-09 211356](https://user-images.githubusercontent.com/89041019/211389193-0bf4a316-a91b-4e6e-9cea-4867e279f45a.png)

<br>
<br>

## Usage

  **1. Download ZIP file from top green button <> Code**
  
  ![Screenshot 2023-01-10 110811](https://user-images.githubusercontent.com/89041019/211515639-9f67bab3-ccda-453d-984e-fc60db88b243.png)

<br>

 **2. Open or download and open [MSSQLServer instance](https://www.microsoft.com/en-us/sql-server/sql-server-downloads "Microsoft official")**
 
 **3. Open CarHire.csproj.user with IDE**
 
 **4. Right click on CarHire and press Manage User Secrets in secret.json write your own connection string**
```javascript
{
  "ConnectionStrings": {
    "DefaultConnection": "your_own_connection_string"
  }
}
```

 **5. Open Package Manager Console choose for Default project : CarHire.Infrastructure and type:**

```javascript
update-database
```

 **6. It is now ready to use. And you can login with seeded users:**
 
 |First name| Last name| Email   | Password   | Role  |
 |-------| ------- | ------------- |:-------------:| -----:|
 | John | Doe  |John@mail.com| 123456 | Admin |
 | Jane | Doe  |Jane@mail.com| 654321 |   n/a |
<br>

![GitHub language count](https://img.shields.io/github/languages/count/Glavyanov/CarHire)
![GitHub all releases](https://img.shields.io/github/downloads/Glavyanov/CarHire/total)
![GitHub forks](https://img.shields.io/github/forks/Glavyanov/CarHire?style=social)
![GitHub Repo stars](https://img.shields.io/github/stars/Glavyanov/CarHire?style=social)
