Feature: Login

@login
Scenario: Login
	Given I navigate to application
	When I click on CONTACT US link
	Then I should see Contact Us page
	And I click on CONTACT link
	And I enter details <Name> and <Email>
	And I upload policy file "FileUpload1"
Examples:
	| Name | Email          |
	| Yug  | yug@gmail.com  |
	#| Vani | vani@gmail.com |