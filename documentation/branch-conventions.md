# Branching Conventions 

We will be managing the following branches with their proper conventions.

## Main 
This branch will be using for releasing new packages.

**Warning**
**Please dn't checkout any branch from Main.**

Naming convention: None (always) Main

## Staging 
This branch will always be checkout from main branch. 
System will automatically be deploying the changes as merged to this branch.
 
**Warning** 
**Please dn't checkout any working branch from Staging.**

Naming convention: constant-version <br/>
constant = stage-v <br/>
version  = 1.0 <br/>

### Example: stage-v1.0

## Feature 
This branch will be using for adding/enhancing/removing any feature from the system. 
Before merging feature to staging QA needs to test this branch properly.

**Note**
**Developer has to checkout working branch always from feature.**

Naming convention: constant-featurename. <br/>
constant = feature- <br/>
name	 = User  <br/>

#### Example: #### feature-user 

## Working Branches 
Developers will be working in these branches, developer has to do development and testing before merging to feature.

Naming convention: constant-nameintials-assigntask <br/>

constant		= dev- <br/>
name initials	= mzk <br/>
assign taks		= continuous integration <br/>

### Example: dev-mazk-continuous-integration

The following are user intials conventions.<br/>
Let's suppose, **Maaz Khan**, taking first and last letter from first name and the first letter from last name.

## Active Users 
|	     USER		 | INITIALS |
|--------------------|----------|
|Maaz Khan           | mzk      |
