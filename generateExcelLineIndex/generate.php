<?php

namespace generateExcelLineIndex;

class Generate
{
    // 行索引字符串
    private $lineIndex = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

    /**
     * 获取行索引
     * @param $index
     * @return string
     * @throws \Exception
     */
    public function getLineIndex($index)
    {
        if ($index < 0)
            throw new \Exception("索引不能小于0！");

        if ($index < 26)
        {
            return strval($this->lineIndex[$index]);
        }
        else if ($index < 26*26)
        {
            $one = strval($this->lineIndex[intval($index/26)-1]);

            $two = strval($this->lineIndex[$index%26]);
            // 形如AA、AB这样的
            return $one.$two;
        }
        else if ($index < 26*26*26)
        {
            $one = strval($this->lineIndex[intval($index/(26*26))-1]);
            $two = strval($this->lineIndex[intval(($index%26)/26)]);
            $three = strval($this->lineIndex[$index%26]);

            // 形如AAA、AAB、AAC...BAA这样的
            return $one.$two.$three;
        }

        throw new \Exception("索引超出处理范围！");
    }
}
