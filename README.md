# MIMLAB
Current Hyper-V lab - 2 DCs, no trust, 1. Contoso.com, 2. GALSYNC.com. simply flows users as contacts in both directions. Simple C# MV ext. Both DCs schema are exchange extended but no exchange needed. Both domains contain an OU named "ExternalContacts" as a managed target OU and RDN is constructed in the MIM MV EXT to target those OUs. 
