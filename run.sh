#!/bin/sh
EXE=svchost.exe
SRC=Shimonizer/Shimonizer.cs
if [ ! -f ${EXE} ] || [ ${SRC} -nt ${EXE} ] ; then
	mcs /out:${EXE} /r:System.Xml.Linq ${SRC} || exit
fi
mono svchost.exe $@
