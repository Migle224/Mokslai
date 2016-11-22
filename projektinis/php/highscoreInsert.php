<?php
	$servername = "localhost";
	$username =  "root";
	$password = "";
	$dbName = "computerarchitecture";
	
	$date 			= $_POST["datePost"];
	$iD 			= $_POST["iDPost"];
	$score 			= $_POST["scorePost"];
	$tasksDone 		= $_POST["tasksDonePost"];
	$tasksDoneRight = $_POST["tasksDoneRightPost"];
	$taskType 		= $_POST["taskTypePost"];
	$time 			= $_POST["timePost"];
	$trainingType 	= $_POST["trainingTypePost"];
	$userName 		= $_POST["userNamePost"];
	
	
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	
	$sql = "INSERT INTO highscore (Date, ID, Score, TasksDone, TasksDoneRight, TaskType, Time, TrainingType, UserName)
			VALUES ('" .$date. "','" .$iD. "','" .$score. "','" .$tasksDone. "','" .$tasksDoneRight. "','" .$taskType. "','" .$time. "','" .$trainingType. "','" .$userName. "')";
	$result = mysqli_query($conn ,$sql);
	
	
	if(!result) echo "there was an error";
	else echo "Everything ok.";
	
?>