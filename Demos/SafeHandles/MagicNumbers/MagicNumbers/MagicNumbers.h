//
//  MagicNumbers.h
//  MagicNumbers
//
//  Created by Mark on 5/28/16.
//  Copyright © 2017 Xamarin. All rights reserved.
//

#ifndef __MagicNumbers__
#define __MagicNumbers__

class MagicNumbers {
private:
    int number;
public:
    MagicNumbers();
    int Value();
};

extern "C" MagicNumbers* CreateMagicNumber();
extern "C" void DeleteMagicNumber( MagicNumbers* p);
extern "C" int GetValue( MagicNumbers *p);

#endif /* defined(__MagicNumbers__) */
