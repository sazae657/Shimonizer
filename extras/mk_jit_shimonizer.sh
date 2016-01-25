#!/bin/sh
if [ "x" = "x${OUT}" ];then
	OUT=shimonizer.sh
fi

cat template/heaer.txt >${OUT}
cat ../Shimonizer.cs | gzip -9 | uuencode -m Shimonizer.cs >>${OUT}
cat template/footer.txt >>${OUT}
chmod +x ${OUT}

