
<!DOCTYPE HTML>
<html>
<head>
<style>
.error {color: #FF0000;}
</style>
</head>
<body>







<p><span class="error">* required field</span></p>
<form style="border:3px; border-style:solid; border-color:gray; padding: 1em;" method="post" action="../controller/signupWardenC.php">
  Book Name: <input type="text" name="BookName" >
  <br><br>
   Book Publisher's Name: <input type="text" name="BookPName">
  <br><br>
  Publish Date: <input type="text" size="1" placeholder="dd" name="PublishDate" > /
  <input type="text" size="1" placeholder="mm" name="birthMonth" > /
  <input type="text" size="2" placeholder="yyyy" name="birthYear" >
  <br><br>
  Publisher's DOB: <input type="text" size="1" placeholder="dd" name="PublisherDOB" > /
  <input type="text" size="1" placeholder="mm" name="birthMonth" > /
  <input type="text" size="2" placeholder="yyyy" name="birthYear" >
  <br><br>
  Book Page Number: <input type="text" name="BookPageN" >
  <br><br>
  Book Type: <select name="types" id="types">
  <option value="sci-fi">sci-fi</option>
  <option value="drama">drama</option>
  <option value="novel">novel</option>
</select>
  <br><br>
  <input type="submit" name="Save" value="Save">
</form>
</body>
</html>