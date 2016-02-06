var express = require('express');
var router = express.Router();

var instruction = '';

/* GET home page. */
router.get('/', function(req, res){
	res.render('index', { title: 'Welcome to our Unity Server' });
});

router.get('/obtainInstruction', function(req, res) {
  res.send(instruction);
  instruction = '';
  //res.send('A get request made');
});

router.post('/up', function(req, res){
	instruction = instruction + 'U';
	res.send(instruction);
});

router.post('/down', function(req, res){
	instruction = instruction + 'D';
	res.send(instruction);
});

router.post('/left', function(req, res){
	instruction = instruction + 'L';
	res.send(instruction);
});

router.post('/right', function(req, res){
	instruction = instruction + 'R';
	res.send(instruction);
});

module.exports = router;
