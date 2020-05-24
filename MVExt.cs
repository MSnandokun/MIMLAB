
using System;
using Microsoft.MetadirectoryServices;

namespace Mms_Metaverse
{
    /// <summary>
    /// Summary description for MVExtensionObject.
    /// </summary>
    public class MVExtensionObject : IMVSynchronization
    {
        #region "Global Declarations"
        ConnectedMA maContacts;
        CSEntry CSEntry;
        string RDN;
        ReferenceValue targetDN;

        #endregion

        public MVExtensionObject()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        void IMVSynchronization.Initialize()
        {
            //
            // TODO: Add initialization logic here
            //
        }

        void IMVSynchronization.Terminate()
        {
            //
            // TODO: Add termination logic here
            //
        }

        void IMVSynchronization.Provision(MVEntry mventry)
        {
            switch (mventry.ObjectType.ToLower())
            {
                //Person - MV Object type to scope provision of contoso users to the GALSync domain, as contact objects, under the "ExternalContacts" OU
                #region case "person":
                case "person":
                    {

                        bool bContactsConnected = false; // reset our boolean 
                        bool bProv = false;
                        if (mventry["mail"].IsPresent) bProv = true;
                        maContacts = mventry.ConnectedMAs["GALSync"]; //Declares MA to Provisions

                        int iNumConnectorsContacts = maContacts.Connectors.Count; // count our connectors to this MA 

                        if (bProv)
                        {
                            if (iNumConnectorsContacts > 0) bContactsConnected = true;
                            RDN = "CN=" + mventry["cn"].Value + ",OU=ExternalContacts" + ",DC=GALSync,DC=com";
                            targetDN = maContacts.CreateDN(RDN); //Created the CS DN
                            if (!(bContactsConnected)) //If not found while iNumConnectorsContacts
                            {
                                CSEntry = maContacts.Connectors.StartNewConnector("contact"); //Starts a new connector
                                CSEntry.DN = targetDN; //Sets the CS DN from targetDN
                                CSEntry["targetAddress"].Value = mventry["mail"].Value; //flows mail attribute MV > CS
                                CSEntry.CommitNewConnector(); //commits the connector to cs db
                            }
                        }
                        break;
                    }
                #endregion case "person"

                //GALSyncPerson - MV Obkect type to scope provision of external contacts from the GALSync.com domain to AD in Contoso under the "ExternalContacts" OU
                #region case "GalSyncPerson":
                case galsyncperson":
                    {

                        bool bContactsConnected = false; // reset our boolean 
                        bool bProv = false;
                        if (mventry["mail"].IsPresent) bProv = true;
                        maContacts = mventry.ConnectedMAs["AD MA"]; //Declares MA to Provisions

                        int iNumConnectorsContacts = maContacts.Connectors.Count; // count our connectors to this MA 

                        if (bProv)
                        {
                            if (iNumConnectorsContacts > 0) bContactsConnected = true;
                            RDN = "CN=" + mventry["cn"].Value + ",OU=ExternalContacts" + ",DC=Contoso,DC=com";
                            targetDN = maContacts.CreateDN(RDN); //Created the CS DN
                            if (!(bContactsConnected)) //If not found while iNumConnectorsContacts
                            {
                                CSEntry = maContacts.Connectors.StartNewConnector("contact"); //Starts a new connector
                                CSEntry.DN = targetDN; //Sets the CS DN from targetDN
                                CSEntry["targetAddress"].Value = mventry["mail"].Value; //flows mail attribute MV > CS
                                CSEntry.CommitNewConnector(); //commits the connector to cs db
                            }
                        }
                        break;
                    }
                    #endregion case "GalSyncPerson"
            }
        }
        bool IMVSynchronization.ShouldDeleteFromMV(CSEntry csentry, MVEntry mventry)
        {
            //
            // TODO: Add MV deletion logic here
            //
            throw new EntryPointNotImplementedException();
        }
    }
}
