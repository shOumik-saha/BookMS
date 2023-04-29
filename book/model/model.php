
<?php

require_once 'connect.php';


function showAllBooks(){
	$conn = db_conn();
    $selectQuery = 'SELECT * FROM `book` ';
    try{
        $stmt = $conn->query($selectQuery);
    }catch(PDOException $e){
        echo $e->getMessage();
    }
    $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);
    return $rows;
}

function showBook($username){
	$conn = db_conn();
	$selectQuery = "SELECT * FROM `book` where Username = '$username'";

    try {
      $stmt = $conn->query($selectQuery);
    } catch (PDOException $e) {
        echo $e->getMessage();
    }
    $row = $stmt->fetchAll(PDO::FETCH_ASSOC);

    return $row;
}

function searchUsername($username){
    $conn = db_conn();
    $selectQuery = "SELECT * FROM `book` WHERE Username = '$username'";


    try{
        $stmt = $conn->query($selectQuery);
    }catch(PDOException $e){
        echo $e->getMessage();
    }
    $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);
    return $rows;
}


function addBookInfo($data){
	$conn = db_conn();
    $selectQuery = "INSERT into book (BookName, BookPName, PublishDate,PublisherDOB,BookPageN,BookType)
VALUES (:BookName, :BookPName, :PublishDate, :PublisherDOB, :BookPageN, :BookType)";
    try{
        $stmt = $conn->prepare($selectQuery);
        $stmt->execute([
        	':BookName' => $data['BookName'],
        	':BookPName' => $data['BookPName'],
        	':PublishDate' => $data['PublishDate'],
					':PublisherDOB' => $data['PublisherDOB'],
					':BookPageN' => $data['BookPageN'],
					':BookType' => $data['BookType'],
          ]);
    }catch(PDOException $e){
        echo $e->getMessage();
    }

    $conn = null;
    return true;
}