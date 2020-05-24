# MIMLAB
Current Hyper-V lab - 2 DCs, no trust, 
1. Contoso.com, 
2. GALSYNC.com 
3. MIM installed in Contoso, no portal


Create both DCs and make sure they can communicate but no trusts needed (Either DNS records or Hostfile entries on both sides.
Extend schema with Exchange ISO (no need to install)
Import MV and MAs > create run profiles for both MAs> run Full import & Full Sync on Contoso, Run export on GALSync > Run Full Import & Full Sync on GALSync, Run Export on Contoso. 



Simply flows users as contacts in both directions. Simple C# MV ext. Both DCs schema are exchange extended but no exchange needed. Both domains contain an OU named "ExternalContacts" as a managed target OU and RDN is constructed in the MIM MV EXT to target those OUs. 
