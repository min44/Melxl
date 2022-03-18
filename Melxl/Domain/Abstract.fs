namespace Melxl.Domain

type NonBinary =
    | Agender
    | Demigender
    | Genderfluid
    | Xenogender
    | Pangender
    | Other

type Gender =
    | Male
    | Female
    | NonBinary of NonBinary