package main

import (
	"./shimonizer"
	"fmt"
	"os"
)

func main() {
	str := os.Args[1]
	fmt.Println(shimonizer.Shimonize(str))
}
