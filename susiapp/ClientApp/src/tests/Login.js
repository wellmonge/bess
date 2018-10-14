import request from 'super-request';

describe('GET /users', function(){
    it('respond with json', function(done){
        request()
        .post('/api/login/authenticationRequest',{ username= '3232', password: '3232'})
        .expect(200, "logged in")
        .end(function(err){
            if(err){
                throw err;
            }
        });
    })
});