# Blazor Subnet Calculator

Simple IPv4 Subnet Calculator developed using Blazor which calculates the number of subnets for an IPv4 address with net mask and number of networks provided by the user.  The app is based on the IPv4 subnetting examples from the Network Layer Addressing and Subnetting Pluralsight course at https://app.pluralsight.com/course-player?clipId=57524c33-f76e-45ad-b8c4-2d9d3a1ffded and the unit test app uses the examples given in this course.

* Two GUI projects developed using Blazor
  * Blazor WASM with PWA/.Net 6 (Is what is currently deployed)
  * Blazor Server/.Net 6
* Subnet Calculator engine is a Class Library project developed using .Net 6
* Unit Test app which uses MSTest in .Net 6 (uses IPv4 sceanrios from Network Layer Addressing and Subnetting Pluralsight course at https://app.pluralsight.com/course-player?clipId=57524c33-f76e-45ad-b8c4-2d9d3a1ffded).  These unit tests are run as part of the GitHub Action when any change occurs in the Blazor WASM GUI project to ensure the Subnet Calcualtor enngine and Blazor WASM GUI project provide the expected results
