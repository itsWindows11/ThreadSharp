# Security Policy

#### This is our policy for reporting security vulnerabilities and overall guidelines on what you should do upon discovering one!

---

<!--
### Supported Versions

Use this section to tell people about which versions of your project are
currently being supported with security updates.

| Version | Supported          |
| ------- | ------------------ |
| 5.1.x   | :white_check_mark: |
| 5.0.x   | :x:                |
| 4.0.x   | :white_check_mark: |
| < 4.0   | :x:                |
-->

## Reporting Security Vulnerabilities

<!--
Use this section to tell people how to report a vulnerability.

Tell them where to go, how often they can expect to get an update on a
reported vulnerability, what to expect if the vulnerability is accepted or
declined, etc.
-->

#### Please use the GitHub Security Advisory "Report a Vulnerability" tab!

In order to report a security vulnerability, you can use GitHub's built-in tool which easily allows you to calculate an _attack vector/CVSS string_ or attribute to an existing [CVE](https://cve.org) code. This allows us to accurately calculate the severity and/or importance of preventing it.

### Spotting secrets in code

If you spot a secret in the code, please let us know by contacting us. This helps us quietly remove the vulnerability without letting others abuse it.
If you notice that we've accidentally published an app credential file or removed it from the `.gitignore` in the project root, please notify us.

## Our Measures
##### What have we done to keep ThreadSharp safe?

### Dependabot

We have implemented Dependabot alerts to automatically track security vulnerabilities that apply to the repository's dependencies.

### Code scanning

We have enabled GitHub Code Scanning to automatically scan our code for potential GitHub client secrets and other API tokens.

### Security advisories

We have enabled GitHub security advisories to let us know if a potential security problem might affect our repository or if something doesn't look right with any of our other security vulnerability countermeasures. This makes it easy to track potential errors or problems that might expose user credentials publicly or cause other similar problems.
