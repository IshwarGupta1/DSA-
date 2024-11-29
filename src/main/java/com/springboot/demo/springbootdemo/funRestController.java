package com.springboot.demo.springbootdemo;

import org.springframework.beans.factory.annotation.*;
import org.springframework.web.bind.annotation.*;

@RestController
public class funRestController {
	//inject property
	@Value("${coach.name}")
	private String coachName;
	
	@Value("${team.name}")
	private String teamName;
	
	@GetMapping("/")
	public String hello()
	{
		return "Hello";
	}
	
	@GetMapping("/workout")
	public String workout()
	{
		return "Run 5 kms now!";
	}
	
	@GetMapping("/teaminfo")
	public String teamInfo()
	{
		return "team coach is "+ coachName + " and team is "+teamName;
	}
	
	

}
