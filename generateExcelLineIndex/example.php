<?php

include "generate.php";

use generateExcelLineIndex\Generate;

$generate = new Generate();

for($i=0; $i<1000; $i++)
    echo "index $i, value ".$generate->getLineIndex($i)."\n";
