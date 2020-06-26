Feature: Add a profile
	As a seller on this portal
	I want to manage my profile effectively

	@Automate
Scenario: Can update a profile using valid input
	Given I have logged into the portal
	When I update skill, education, certification and language
	Then I should be able to see the updated record

@Automate
Scenario: Add a profile using valid input
	Given I have logged into the portal
	When I add language, skill, education and certification 
	Then I should be able to view the record

@Automate
Scenario: Add availability in the profile
	Given I have logged into the portal
	When I add availability 
	Then I should be able to get confirmation message

@Automate
Scenario: Remove the language, skills, education and certification
	Given I have logged into the portal
	When I remove  certification, skill, education and language
	Then I should be able to see a confirmation message

Scenario: Cannot add a profile using existing input
	Given I have logged into the portal
	When I have added existing inputs in skills, language, education and certification
	Then I should be able to get an error message

Scenario: Add multiple skills, education, certification and languages
	Given I have logged into the portal
	When I have entered multiple skills, education, certification and languages
	And I press add
	Then I should be able to see confirmation message

Scenario: Add Description upto 600 characters
	Given I have logged into the portal
	When I have entered description using 600 characters
	And I press add
	Then I should be able to see the confirmation message

Scenario: Cannot add Description using more than 600 characters
	Given I have logged into the portal
	When I have entered description using 601 characters
	Then I should not be allowed to add more than 600 characters

Scenario: Cannot add a profile using invalid input
	Given I have logged into the portal
	And I have added invalid inputs in skills, language, education and certification
	When I click add
	Then I should be able to get an error message

Scenario: A non existing seller cannot view the profile
	Given I go to the profile page
	When I should see a login pop up
	And I need to join the mars portal
	Then I can access the profile

Scenario: View profile 
	Given I have logged into the portal
	When I am directed to profile section
	Then I should be able to see my profile

Scenario: A seller cannot view the profile without logging in
	Given I go to the profile page
	When I should see a login pop up
	And I need to login into the portal
	Then I can view the profile

Scenario: Add a profile using null input
	Given I have logged into the portal
	When I enter null value in skill, language, education and certification
	And I click add
	Then I should be able to get an error message

Scenario: A seller cannot add the profile without logging in
	Given I go to the profile page
	And I should see a login pop up
	When I need to login into the portal
	Then I can add the profile
	And I should be able to see the confirmation message

Scenario: Cannot update the language, skills, education and certification with null values
	Given I have logged into the portal
	When I update education, certification, skill and language with null value
	Then I should be able to get an error message

Scenario: A seller cannot update the language, skills, education and certification without logging in
	Given I go to the profile page
	And I should see a login pop up
	When I can login into the portal
	Then I can update the hours, earn target, skill and language

Scenario: Update Description using null value
	Given I have logged into the portal
	When I have entered description using null values
	And I press update
	Then I should be able to see an error message


Scenario: Remove the language, skills, education and certification without logging in
	Given I go to the profile page
	And I should see a login pop up
	When I login into the portal
	Then I can remove education, certifications, skill and language