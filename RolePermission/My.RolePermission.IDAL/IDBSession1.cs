
namespace My.RolePermission.IDAL
{
	public partial interface IDBSession
    {
		ISMEXCEPTIONTBRepository ISMEXCEPTIONTBRepository{get;set;}
		ISMFIELDRepository ISMFIELDRepository{get;set;}
		ISMFUNCTBRepository ISMFUNCTBRepository{get;set;}
		ISMLOGRepository ISMLOGRepository{get;set;}
		ISMMENUROLEFUNCTBRepository ISMMENUROLEFUNCTBRepository{get;set;}
		ISMMENUTBRepository ISMMENUTBRepository{get;set;}
		ISMROLETBRepository ISMROLETBRepository{get;set;}
		ISMUSERTBRepository ISMUSERTBRepository{get;set;}
    }
}