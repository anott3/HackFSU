var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
  //res.send('A get request made');
});

router.post('/up', function(req, res){
	res.send('Up Sent');
});

router.post('/down', function(req, res){
	res.send('Down Sent');
});

router.post('/left', function(req, res){
	res.send('Left Sent');
});

router.post('/right', function(req, res){
	res.send('Right Sent');
});

module.exports = router;
