Feature: WebAndAPICombo

A short summary of the feature
@login @DataSource:Data/GetUserByID.xlsx
Scenario: Login with API data
	Given I navigate to application
	When I click on CONTACT US link
	Then I should see Contact Us page
	And I click on CONTACT link
	Given The test case title is '<testcase>'
	When User makes a '<method>' call at the '<endpoint>'
	And User executes the api call
	Then User should expect '<response_code>' response code
	And User enters api data userName and email
	And I upload policy file "FileUpload1"