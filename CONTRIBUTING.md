Thanks for contributing to ADAPT. We're glad to have your help.

< Add in contribution guidelines here >

# Contributing legal guidelines

You may only contribute to this repository if you can agree to the following:

>I contribute this work to this project under the terms of the Eclipse Public License, version 1.0
>
By making a contribution to this project, I certify that:

>>(a) The contribution was created in whole or in part by me and I
    have the right to submit it under the open source license
    indicated in the file; or
>>
(b) The contribution is based upon previous work that, to the best
    of my knowledge, is covered under an appropriate open source
    license and I have the right under that license to submit that
    work with modifications, whether created in whole or in part
    by me, under the same open source license (unless I am
    permitted to submit under a different license), as indicated
    in the file; or
>>
(c) The contribution was provided directly to me by some other
    person who certified (a), (b) or (c) and I have not modified
    it.
>>
(d) I understand and agree that this project and the contribution
    are public and that a record of the contribution (including all
    personal information I submit with it, including my sign-off) is
    maintained indefinitely and may be redistributed consistent with
    this project or the open source license(s) involved.

If you agree, you must indicate it by adding the following line to the bottom of your Git
commit messages for every commit in your submission:

    Signed-off-by: Random J Developer <random@developer.example.org>
using you real name and email. (sorry, no pseudonyms or anonymous contributions.)

***Under no circumstances will a commit be accepted without a valid `Signed-off-by` line.***

>If you're using the command line, you can have git add this line for you.
By adding the `-s` flag your `Signed-off-by` line will added for you using your
global name and email. As an example:
```
>> git commit -s
```
will open your text editor with your `Signed-off-by` line at the end of it.

Additionally, please add your description to license notice of the file.

## License notices on new files
If you're adding a new file to ADAPT, including which have come from another project,
you'll need to add the following license notice block to the file (with only a few exceptions):

```
/*******************************************************************************
 * Copyright (c) 2015 AgGateway and ADAPT Contributors
 * {ADDITIONAL COPYRIGHT HOLDERS}
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    {INITIAL AUTHOR} - {DESCRIPTION}
 *******************************************************************************/
```

You can copy and paste the license notice but there are a few things you'll need to
add:
* For {ADDITIONAL COPYRIGHT HOLDERS} you may add any other entities which have
copyright on the code using the format from the first line. For example, if
Acme Corporation owned a copyright on some of the code you added to the file in 2017 and their copyright began in 2016, you'd add
```
Copyright (c) 2016-2017 Acme Corporation
```
* In the case of code you've copied from another source, make sure to add the
copyright holder from the original source code if you have it.
* Please don't guess at copyright holder lines. It's better to not have them in
there than to have them incorrect.

* {INITIAL AUTHOR} should be your name
* {DESCRIPTION} is a simple description of the changes made.

While preferable to place the license notice at the beginning of the file, it's not required.
In the cases of files where a leading notice would be unpleasant to the reader, the
notice may be placed at the end of the file. These are mostly text files, such
as READMEs and documentation (or this file).

### Exceptions
A few files don't need a license notice. These files are:

* **CONTRIB file** which contain the text of all the licenses for the open source software
in the repository and is in the root of the project.
* **LICENSE file** which contain the text of the EPL and is in the root of the project
* **Technologically exempt files.** Some files added to a repository may have no reasonable way to add or keep a license notice. As an example, some binary file formats have no mechanism for holding a license notice. Additionally, certain text formats would break if a license notice were added (I believe .sln files). These files are exempt from the license notice requirement. They are licensed under the Eclipse Public License though as indicated by the root-level LICENSE file.

## Using code from other sources

Consistent with the principles of open source, you may incorporate source code licensed under some other open source software licenses, or compatible licenses. In all cases, you must comply with the terms of the license. The current policy of ADAPT is that source code can be incorporated if it's licensed under one of the following compatible licenses:

* Apache License, versions 1.1 and  2
* BSD License (2 or 3 clause)
* MIT/x11 license
* Eclipse Public License 1.0
* Creative Commons, Attribution License, versions 1-4
* Public Domain code

In all cases, you must clearly indicate where the code came from and what license you believe it's under.

### Proper Attribution
Any time you include open source code (or link to it), you must properly attribute where it comes from. Not
only is this being a good open source citizen, in many cases, it is required by the original code's licenses.

If you copy in code, you have to make sure that the exact license text is included in the
CONTRIB file. The description of the CONTRIB file is at https://aggateway.atlassian.net/wiki/display/ADAPT/Contribution+Guidelines+-+Recommendation.

Additionally, you must do a few others things depending on whether you're copying in a whole file (or most of a file) or a small part of a file.

#### Copying in parts of a file
If you're only copying in parts of a file, make sure to do the following:
* Comment the sections where you copied in code the url where the code is from and
the name of the license.
* Add the copyright holder of the code to the {ADDITIONAL COPYRIGHT HEADERS} section

#### Copying in whole open source files
Follow the section titled: "License notices on new files". Also make sure to
include copyright holder from the original project into your license notice.

#### Clarifications
In certain cases, you may be asked to clarify whether you copied code in from other places.
Don't take this personally; it's simply that the technical leaders want to better
understand where the code comes from in order to protect users of ADAPT.

**License:**
```
/*******************************************************************************
 * Copyright (c) 2015 AgGateway and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    Eric Schultz - initial version
 *******************************************************************************/```
