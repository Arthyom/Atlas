namespace Core.Enums;


public enum AtlasEnumShippingStatus
{
    Created = 1,
    
    InternalPackageInfoSaved = -1,
    InternalPackageCompSaved = -2,
    InternalPackagePdfSaved = -3,
    InternalPackageReadyForSending = -4,
    InternalPackageWaitingPickup = -5,

    Preparing = 2,
    InTransit = 3,
    Delivered = 4,
    Cancelled = 5
}