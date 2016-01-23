#!/bin/sh
EXE=svchost.exe
if [ ! -f ${EXE} ];then 
	mcs /out:${EXE} /r:System.Xml.Linq Shimonizer.cs || exit
fi
mono svchost.exe $@
