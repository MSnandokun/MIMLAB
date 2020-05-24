# MIMLAB
Current Hyper-V lab - 2 DCs, no trust, 
1. Contoso.com, 
2. GALSYNC.com 
3. MIM installed in Contoso, no portal

Instructions
1. Create both DCs and make sure they can communicate but no trusts needed (Either DNS records or Hostfile entries on both sides.
2. Extend schema with Exchange ISO (no need to install) - https://docs.microsoft.com/en-us/Exchange/plan-and-deploy/prepare-ad-and-domains?view=exchserver-2019#step-1-extend-the-active-directory-schema 
3. Standard install of MIM - Synchronization service only (no portal needed for this lab)
a. Import MV & MA schema from config file in ZIP folder 
b. create run profiles for both MAs 
c. run Full import & Full Sync on Contoso 
d. Run export on GALSync 
e. Run Full Import & Full Sync on GALSync 
f. Run Export on Contoso. 

The goal of this lab was to keep it as simple as possible and make the MVEXT.DLL code as simple as possible for learning purposes. Theres better ways to do this but I took an assumption of little or no knowlege of neither C# or MIM. Feel free to break it apart and use it to learn or as a starting point for a similar project. All code and settings are presented as an example and no guarantees are made. Microsoft does not sponsor any of these materials as they are presented as a learning tool. Feel free to contact me if you need help. 

The lab simply flows users as contacts in both directions using a simple C# MV ext. Both DCs schema are exchange extended but no exchange needed. Both domains contain an OU named "ExternalContacts" as a managed target OU and RDN is constructed in the MIM MV EXT to target those OUs. 

Any questions or comments I can be reached at fernando.rivera@microsoft.com :)
