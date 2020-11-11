<template>
  <div>
    <div class="product-search">
      <input type="text" id="txtSearch" />
      <button>搜索</button>
    </div>
    <hr />
  </div>
</template>
<style >

* {
  padding: 0;
  margin: 0;
}
.product-search {
  
  width: 704px;
  height: 44px;
  margin: auto;
   
}
#txtSearch {
  width: 600px;
  height: 32px;
  border: 6px solid red;
  float: left;
  outline: none;
  padding: 0 6px;
}

button {
  width: 80px;
  height: 44px;
  border: 0 none;
  background: red;
  color: #fff;
  float: left;
  outline: none;
}
hr {
  margin-top: 60px;
  border: 2px solid red;
}
</style>