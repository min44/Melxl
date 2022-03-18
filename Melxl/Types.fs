module Melxl.Types

type KindOfNonBinary =
    | Agender
    | Demigender
    | Genderfluid
    | Xenogender
    | Pangender
    | Other

type Gender =
    | Male
    | Female
    | NonBinary of KindOfNonBinary