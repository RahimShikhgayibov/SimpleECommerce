namespace SimpleECommerce.Application;

public abstract class ErrorMessages
{
    public const string ErrorOccured = "ERROR_OCCURED";
    public const string UserNotFound = "USER_NOT_FOUND";
    public const string UserAlreadyExists = "USER_ALREADY_EXISTS";
    public const string UserNotActive = "USER_NOT_ACTIVE";
    public const string UserIncorrect = "USER_INCORRECT";
    public const string UserTokenInvalid = "USER_TOKEN_INVALID";
    public const string UserNotAccess = "USER_NOT_ACCESS";
    public const string UserAlreadyActivated = "USER_ALREADY_ACTIVATED";
    public const string UserAlreadyDeactivated = "USER_ALREADY_DEACTIVATED";

    public const string RoleNotFound = "ROLE_NOT_FOUND";
    public const string RoleNotEditable = "ROLE_NOT_EDITABLE";
    public const string RoleAlreadyExists = "ROLE_ALREADY_EXISTS";
    public const string RoleAlreadyActivated = "ROLE_ALREADY_ACTIVATED";
    public const string RoleAlreadyDeactivated = "ROLE_ALREADY_DEACTIVATED";
    public const string TicketAlreadyAssigned = "TICKET_ALREDY_ASSIGNED";

    public const string PermissionNotFound = "PERMISSION_NOT_FOUND";
    
    public const string SnapshotNotFound = "SNAPSHOT_NOT_FOUND";
    
    public const string NotificationNotFound = "NOTIFICATION_NOT_FOUND";
    public const string NotificationAlreadyRead = "NOTIFICATION_ALREADY_READ";
    
    public const string TicketNotFound = "TICKET_NOT_FOUND";
    public const string TicketMessageNotFound = "TICKET_MESSAGE_NOT_FOUND";
    public const string TicketMessageAttachmentNotFound = "TICKET_MESSAGE_ATTACHMENT_NOT_FOUND";
    public const string TicketAlreadyClosed = "TICKET_ALREADY_CLOSED";
        
    public const string PositionNotFound = "POSITION_NOT_FOUND";
    public const string PositionAlreadyExists = "POSITION_ALREADY_EXISTS";
    public const string PositionAlreadyActivated = "POSITION_ALREADY_ACTIVATED";
    public const string PositionAlreadyDeactivated = "POSITION_ALREADY_DEACTIVATED";
    
    public const string FaqItemNotFound = "FAQ_ITEM_NOT_FOUND";
    public const string FaqItemAlreadyActivated = "FAQ_ITEM_ALREADY_ACTIVATED";
    public const string FaqItemAlreadyDeactivated = "FAQ_ITEM_ALREADY_DEACTIVATED";
}