# Branching Conventions 

We will be managing the following branches with their proper conventions.

## Main 
This branch will be using for releasing new packages.

**Warning**
**Please dn't checkout any branch from Main.**

Naming convention: None (always)<Main>

## Staging 
This branch will always be checkout from main branch. 
System will automatically be deploying the changes as merged to this branch.
 
**Warning** 
**Please dn't checkout any working branch from Staging.**

Naming convention: <constant>-<version>
constant = stage-v
version  = 1.0

### Example: stage-v1.0

## Feature 
This branch will be using for adding/enhancing/removing any feature from the system. 
Before merging feature to staging QA needs to test this branch properly.

**Note**
**Developer has to checkout working branch always from feature.**

Naming convention: <constant>-<feature-name>
constant = feature-
name	 = User 

### Example: feature-user 

## Working Branches 
Developers will be working in these branches, developer has to do development and testing before merging to feature.

Naming convention: <constant>-<name intials>-<assign task>

constant		= Dev-
name initials	= mzk
assign taks		= continuous integration

### Example: Dev-mazk-continuous-integration

The following are user intials conventions.

### Example: Maaz Khan, taking first and last letter from first name and the first letter from last name.

## Active Users 
|	     USER		 | INITIALS |
|--------------------|----------|
|Maaz Khan           | mzk      |
