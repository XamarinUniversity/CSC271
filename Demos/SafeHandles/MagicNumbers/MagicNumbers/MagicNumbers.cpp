//
//  MagicNumbers.cpp
//  MagicNumbers
//
//  Created by Mark on 5/28/16.
//  Copyright © 2018 Xamarin Inc., Microsoft. All rights reserved.
//

#include <stdio.h>
#include "MagicNumbers.h"

MagicNumbers::MagicNumbers()
{
    number = 42;
}

int MagicNumbers::Value()
{
    return number;
}

extern "C" MagicNumbers* CreateMagicNumber()
{
    return new MagicNumbers();
}

extern "C" void DeleteMagicNumber( MagicNumbers* p)
{
    if (p != NULL) {
        delete p;
    }
}
extern "C" int Value( MagicNumbers *p)
{
    if (p != NULL) {
        return p->Value();
    }
    return -1;
}
