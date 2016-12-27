<?php
	$servername = "localhost";
	$username =  "root";
	$password = "";
	$dbName = "computerarchitecture";
	
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	
	$sql = "SELECT Date, ID, Score, TasksDone, TasksDoneRight, TaskType, Time, TrainingType, UserName FROM highscore ORDER BY Score ASC";
	$result = mysqli_query($conn ,$sql);
	
	
	if(mysqli_num_rows($result) > 0){
		//show data for each row
		while($row = mysqli_fetch_assoc($result)){
			echo "".$row['Date'].";".$row['ID'].";".$row['Score'].";".$row['TasksDone'].";".$row['TasksDoneRight'].";".$row['TaskType'].";".$row['Time'].";".$row['TrainingType'].";".$row['UserName']."|"."<br>";
		}
	}
	
	
	
	


?>