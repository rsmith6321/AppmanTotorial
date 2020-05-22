โฟลเดอร์ที่เป็นโจทย์หลักคือ StudentUniversityTest โดยเป็น web api สร้างมาจาก asp.net framework implement ด้วย C# ซึ่งโปรเจคนี้เป็นการทำงานในรูปแบบmvc แต่ webapi ที่ทำไปจะใช้แค่2ส่วนเท่านั้นคือ Model และ Controller 

ใช้postmanในการทำ testing http method ต่างๆ


ภาพรวมตอนนี้คือ 
- ในส่วนของ model สร้าง Student Class และ University Class และสามารถเชื่อม dbContext ของทั้งสองclass และสร้าง controller ของทั้งสองclassเรียบร้อยแล้ว
- สามารถใช้ ้ http method ตามที่โจทย์ให้มาได้ทั้ง2classแล้ว(get(),get(id),post(),put(),delete()) แต่ไม่มีการqueryข้อมูลตามrelationที่โจทย์ให้มา (รูป Diag2)
- การรับ client request และส่ง response จะเป็นหน้าที่ของcontroller 
- การทำงานของclassทั้ง2classยังไม่มีrelationเชื่อมกันและกัน


- การทำงานของระบบนี้จะใช้EntityFrameworkCore ซึ่งราไม่สามารถเก็บค่าattributeในตารางในรูปแบบ arrayได้ ดังนั้นเราต้องมีตัวกลางในการเชื่อมและquery ตาราง University และ Student (รูป Diag3)

- ที่คิดไว้คือ เนื่องจากความสัมพันธ์ที่โจทย์ให้มาเป็นแบบ m:n ซึ่ง framework นี้ไม่สามารถทำความสัมพันธ์ดังกล่าวได้ เพราะงั้นต้องสร้าง Relationclass ขึ้นมาตรงกลางเพื่อให้มันเป็นความสัมพันธ์แบบ 1:n และ m:1 ตามลำดับ แต่ตอนนี้ยังไม่ค่อยเข้าใจการทำงานของ api framework เลยไม่ทราบว่าต้องสร้าง relation ระหว่างกันยังไง แล้ว การส่งrequest จะทำผ่าน controller ดังนั้นที่ผมคิดไว้คือ หลังจากที่สร้าง relation class เสร็จ เราต้องทำcontroller ให้สามารถรับค่า student และ university มาให้อยู่ใน relationClass และสามารถส่งค่า(respone)กลับให้client ได้ (รูป Diag1)


folder อื่นเป็นtutorialที่ลองทำเพื่อศึกษา .netcore ละในplaygroundจะเป็นโฟลเดอร์ที่ใช้ยำเพื่อเรียนรู้ webApi ของ asp.net ซึ่งตอนนี้พังไปแล้ว

สามารถดูรูปdiagramที่ผมลองเขียนประกอบได้ใน folder picture 

ขอบคุณครับ